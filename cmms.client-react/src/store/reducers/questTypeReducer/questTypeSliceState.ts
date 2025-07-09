import { QuestTypeResponse } from "../../../models/QuestType/QuestTypeResponse"

export interface QuestTypeSliceState {

    loading: boolean,
    questTypes: QuestTypeResponse[]
}