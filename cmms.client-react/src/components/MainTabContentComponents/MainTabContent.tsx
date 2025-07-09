import { Menu } from 'antd';
import { Tabs } from 'antd';
import { AppstoreOutlined, MailOutlined, SettingOutlined } from '@ant-design/icons';
import { useEffect, useState } from 'react';
import QuestTable from '../Quest/QuestTable';
import QuestTypeTable from '../QuestType/QuestTypeTable';

const MainTabContent = (props) => {
    let [tabsItems, setTabsItems] = useState<Array<any>>(props.tabsItems);

    const [activeKey, setActiveKey] = useState();

    useEffect(() => {
        setTabsItems(props.tabsItems);
    }, [props.tabsItems]);

    function getTabPaneComponentByKey(key: string): any {
        switch (key) {
            case 'QuestGridKey': {
                return (
                    <QuestTable/>
                );
                break;
            }
            case 'QuestTypeGridKey': {
                return (
                    <QuestTypeTable />
                );
                break;
            }
            case 'EquipmentGridKey': {
                return (
                    { tab: 'Urz¹dzenia', key: key }
                );
                break;
            }
            case 'EquipmentSetGridKey': {
                return (
                    { tab: 'Grupy urz¹dzeñ', key: key }
                );
                break;
            }
            case 'UserGridKey': {
                return (
                    { tab: 'U¿ytkownicy', key: key }
                );
                break;
            }
            default: {
                return (
                    { tab: key, key: key }
                );
                break;
            }
        }
    }

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

    function getTabPaneByTabInfo(tabInfo: any): any{
        return (
            <Tabs.TabPane tab={tabInfo.tab} key={tabInfo.key}>
                {getTabPaneComponentByKey(tabInfo.key)}                
            </Tabs.TabPane>
        );
    }

    return (
        <>
            <Tabs
                type='editable-card'
                activeKey={activeKey}
                //activeKey={props.focusTab}
                hideAdd={true}
                onEdit={onEdit}
            >
            {tabsItems.map((tabInfo, index) => {
                return getTabPaneByTabInfo(tabInfo)
            })}
            </Tabs>
        </>
    )
}
export default MainTabContent;



