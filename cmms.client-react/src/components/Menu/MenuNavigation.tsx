import { Menu } from 'antd';
import type { MenuProps } from 'antd';
import { AppstoreOutlined, MailOutlined, SettingOutlined } from '@ant-design/icons';

type MenuItem = Required<MenuProps>['items'][number];

const MenuNavigation = (props) => {


    const items: MenuItem[] = [
        {
            key: 'equipment',
            label: 'Equipment',
            icon: <MailOutlined />,
            children: [
                { key: 'EquipmentGridKey', label: 'Equipment' },
                { key: 'EquipmentSetGridKey', label: 'Equipment set' },
            ],
        },
        {
            key: 'quest',
            label: 'Quest',
            icon: <AppstoreOutlined />,
            children: [
                { key: 'QuestGridKey', label: 'Quest' },
                { key: 'QuestTypeGridKey', label: 'Quest type' },
            ],
        },
        {
            key: 'user',
            label: 'User',
            icon: <AppstoreOutlined />,
            children: [
                { key: 'UserGridKey', label: 'User' },
            ],
        },
    ];
  

    const onClick: MenuProps['onClick'] = (e) => {
        props.addTabByKey(e.key);
    };

    return (
        <div>
            <Menu
                onClick={onClick}
                style={{ width: 200, height: '100%' }}
                defaultSelectedKeys={['1']}
                defaultOpenKeys={['sub1']}
                mode="inline"
                items={items}
            />
        </div>
    )
}

export default MenuNavigation