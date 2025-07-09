import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store";
import { QuestResponse } from "../../models/Quest/QuestResponse";
import { Space, Table, Popconfirm, Button, type TableColumnsType, type TableProps } from 'antd';
import { getQuestList } from "../../store/utils/thiunks/questThunks";

const QuestTable = () => {

    const questList = useSelector((state: RootState) => state.quests);
    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(getQuestList())
            .unwrap()
            .then((data) => {
                // setQuestTypeList(data);
            })
        //const fetchData = async () => {
        //    const fetchQuestitemList = await apiConnector.getQuestList();
        //    setQuestList(fetchQuestitemList);
        //}

        //fetchData();
    }, []);

    const handleDelete = async (id: any) => {
        //var resp = await apiConnector.deleteQuest(id as string);
        //const newData = questList.filter((item) => item.id !== id);
        //setQuestList(newData);
    };

    const columns: TableColumnsType<QuestResponse> = [
        {
            title: 'Name',
            dataIndex: 'name',
            showSorterTooltip: { target: 'full-header' },
            sorter: (a, b) => a.name.length - b.name.length,
            sortDirections: ['descend'],
            filterSearch: true,
        },
        {
            title: 'Description',
            dataIndex: 'description',
            showSorterTooltip: { target: 'full-header' },
            sorter: (a, b) => a.name.length - b.name.length,
            sortDirections: ['descend'],
            filterSearch: true,
        },
        {
            title: 'Priority',
            dataIndex: 'priority',
        },
        {
            title: 'action',
            dataIndex: 'defaultPriority',
            render: (_, record) => (
                <Space size="middle">
                    <a>Edit</a>
                    <Popconfirm title="Sure to delete?" onConfirm={() => handleDelete(record.id)}>
                        <a>Delete</a>
                    </Popconfirm>
                </Space>
            ),
        }

    ];
    const handleAdd = () => {
        //const newData = {
        //    key: count,
        //    name: `Edward King ${count}`,
        //    age: '32',
        //    address: `London, Park Lane no. ${count}`,
        //};
        //setDataSource([...dataSource, newData]);
        //setCount(count + 1);
    };
    return (
        <div>
            <Button onClick={handleAdd} type="primary" style={{ marginBottom: 16 }}>
                Add a row
            </Button>
            <Table<QuestResponse>
                className="quest-table"
                rowKey="id"
                columns={columns}
                dataSource={questList.quests}
                showSorterTooltip={{ target: 'sorter-icon' }}
            />
        </div>
    )
}

export default QuestTable
