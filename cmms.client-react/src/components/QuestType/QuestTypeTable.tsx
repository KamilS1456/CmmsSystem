import { useEffect, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { QuestTypeResponse } from "../../models/QuestType/QuestTypeResponse";
import { Space, Table, Popconfirm, Button, type TableColumnsType, type TableProps } from 'antd';
import { RootState } from "../../store";
import { getQuestTypeList } from "../../store/utils/thiunks/questTypeThunks";

const QuestTypeTable = () => {
    const questTypeList = useSelector((state: RootState) => state.questTypes);
    const dispatch = useDispatch();

    //const [questTypeList, setQuestTypeList] = useState<QuestTypeResponse[]>();
    useEffect(() => {
        dispatch(getQuestTypeList())
            .unwrap()
            .then((data) => {
                // setQuestTypeList(data);
            })
        //const fetchData = async () => {
        //    const fetchQuestTypeitemList = await apiConnector.getQuestTypeList();
        //    setQuestTypeList(fetchQuestTypeitemList);
        //}

        //fetchData();
    }, []);

    const handleDelete = async (id: any) => {
        //var resp = await apiConnector.deleteQuestType(id as string);
        //const newData = questTypeList.filter((item) => item.id !== id);
        //setQuestTypeList(newData);
    };

    const columns: TableColumnsType<QuestTypeResponse> = [
        {
            title: 'Name',
            dataIndex: 'name',
            showSorterTooltip: { target: 'full-header' },
            sorter: (a, b) => a.name.length - b.name.length,
                sortDirections: ['descend'],
                    filterSearch: true,
        },
        {
            title: 'Priority',
            dataIndex: 'defaultPriority',
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
            <Table<QuestTypeResponse>
                className="quest-Type-table"
                rowKey="id"
                columns={columns}
                dataSource={questTypeList.questTypes}
                showSorterTooltip={{ target: 'sorter-icon' }}
            />
        </div>
    )
}

export default QuestTypeTable