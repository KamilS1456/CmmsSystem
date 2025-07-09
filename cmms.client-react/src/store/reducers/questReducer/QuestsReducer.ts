import { createSlice } from "@reduxjs/toolkit";
import { QuestSliceState } from "./questTypeSliceState";
import { getQuestList} from "../../utils/thiunks/questThunks";
import { QuestResponse } from "../../../models/Quest/QuestResponse";

const initialState: QuestSliceState = {
    loading: true,
    quests: [] as QuestResponse[]
};

export const questTypeSlice = createSlice({
    name: "questTypes",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getQuestList.pending, (state: QuestSliceState) => {
                state.loading = true;
            })
            .addCase(getQuestList.fulfilled, (state: QuestSliceState, action) => {
                state.loading = false;
                state.quests = action.payload;
            })
            .addCase(getQuestList.rejected, (state: QuestSliceState) => {
                state.loading = false;
            });
    }
})
export default questTypeSlice.reducer;