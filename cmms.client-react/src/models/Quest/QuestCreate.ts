import { QuestToEquipmentDto } from "./QuestToEquipmentDto"
import { QuestToUserDto } from "./QuestToUserDto"

export interface QuestCreate {
    name: string,
    description: string,
    deadLineDataTime: string,
    priority: number
    questState: number,
    questTypeId: string,

    questToUsers: QuestToUserDto[],
    questToEquipments: QuestToEquipmentDto[]

}