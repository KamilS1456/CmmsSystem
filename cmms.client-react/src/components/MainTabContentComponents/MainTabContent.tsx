import { Tabs } from 'antd';
import { useEffect, useState } from 'react';
import { ITabsItems } from './ITabsItems';
import { getTabPaneComponentByKey } from './TabsProvider';
import type { DragEndEvent } from '@dnd-kit/core';
import { closestCenter, DndContext, PointerSensor, useSensor } from '@dnd-kit/core';
import {
    arrayMove,
    horizontalListSortingStrategy,
    SortableContext,
    useSortable,
} from '@dnd-kit/sortable';
import { CSS } from '@dnd-kit/utilities';
import type { TabsProps } from 'antd';
import React from 'react';

const MainTabContent = (props) => {
    let [tabsItems, setTabsItems] = useState<Array<ITabsItems>>(props.tabsItems);

    const [activeKey, setActiveKey] = useState<string>(props.focusTab);

    const sensor = useSensor(PointerSensor, { activationConstraint: { distance: 10 } });

    interface DraggableTabPaneProps extends React.HTMLAttributes<HTMLDivElement> {
        'data-node-key': string;
    }

    const DraggableTabNode: React.FC<Readonly<DraggableTabPaneProps>> = ({ className, ...props }) => {
        const { attributes, listeners, setNodeRef, transform, transition } = useSortable({
            id: props['data-node-key'],
        });

        const style: React.CSSProperties = {
            ...props.style,
            transform: CSS.Translate.toString(transform),
            transition,
            cursor: 'move',
        };

        return React.cloneElement(props.children as React.ReactElement<any>, {
            ref: setNodeRef,
            style,
            ...attributes,
            ...listeners,
        });
    };

    useEffect(() => {
        setTabsItems(props.tabsItems);
    }, [props.tabsItems]);



    const remove = (targetKey: TargetKey) => {
        const targetIndex = tabsItems.findIndex((pane) => pane.key === targetKey);
        const newPanes = tabsItems.filter((pane) => pane.key !== targetKey);
        if (newPanes.length && targetKey === activeKey) {
            const { key } = newPanes[targetIndex === newPanes.length ? targetIndex - 1 : targetIndex];
            setActiveKey(key);

        }
        setTabsItems(newPanes);
        props.removeTabByKey(targetKey)

    };

    const onEdit = (targetKey: TargetKey, action: 'add' | 'remove') => {
        if (action === 'remove') {
            remove(targetKey);
        }
    };

    const onDragEnd = ({ active, over }: DragEndEvent) => {
        if (active.id !== over?.id) {
            setTabsItems((prev) => {
                const activeIndex = prev.findIndex((i) => i.key === active.id);
                const overIndex = prev.findIndex((i) => i.key === over?.id);
                return arrayMove(prev, activeIndex, overIndex);
            });
        }
    };

    return (
        <>
            <Tabs
                type='editable-card'
                activeKey={activeKey}
                //activeKey={props.focusTab}
                hideAdd={true}
                onEdit={onEdit}
                items={tabsItems.map(tabInfo => ({
                    key: tabInfo.key,
                    label: tabInfo.tab,
                    children: getTabPaneComponentByKey(tabInfo.key)
                }))}
                renderTabBar={(tabBarProps: TabsProps, DefaultTabBar) => (

                    <DndContext sensors={[sensor]} onDragEnd={onDragEnd} collisionDetection={closestCenter}>
                        <SortableContext items={tabsItems.map((i) => i.key)} strategy={horizontalListSortingStrategy}>
                            <DefaultTabBar rtl={false} mobile={false} {...tabBarProps}>
                                {(node) => (
                                    <DraggableTabNode
                                        {...(node as React.ReactElement<DraggableTabPaneProps>).props}
                                        key={node.key}
                                    >
                                        {node}
                                    </DraggableTabNode>
                                )}
                            </DefaultTabBar>
                        </SortableContext>
                    </DndContext>
                )}
            />
        </>
    )
}
export default MainTabContent;



