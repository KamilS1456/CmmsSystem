import { ITabsItems } from "./ITabsItems";
import QuestTable from '../Quest/QuestTable';
import QuestTypeTable from '../QuestType/QuestTypeTable';
export function getTabByKey(key: string): ITabsItems {
    switch (key) {
        case 'QuestGridKey': {
            return (
                { tab: 'Zadanie', key: key }
            );
            break;
        }
        case 'QuestTypeGridKey': {
            return (
                { tab: 'Typ zadania', key: key }
            );
            break;
        }
        case 'EquipmentGridKey': {
            return (
                { tab: 'Urządzenia', key: key }
            );
            break;
        }
        case 'EquipmentSetGridKey': {
            return (
                { tab: 'Grupy urządzeń', key: key }
            );
            break;
        }
        case 'UserGridKey': {
            return (
                { tab: 'Użytkownicy', key: key }
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

export function getTabPaneComponentByKey(key: string): any {
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
                { tab: 'Urządzenia', key: key }
            );
            break;
        }
        case 'EquipmentSetGridKey': {
            return (
                { tab: 'Grupy urządzeń', key: key }
            );
            break;
        }
        case 'UserGridKey': {
            return (
                { tab: 'Użytkownicy', key: key }
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