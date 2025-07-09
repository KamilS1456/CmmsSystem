import { QuestResponse } from "../../../models/Quest/QuestResponse"

export interface QuestSliceState {

    loading: boolean,
    quests: QuestResponse[]
}