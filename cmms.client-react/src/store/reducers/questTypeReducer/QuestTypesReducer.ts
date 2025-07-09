import { createSlice } from "@reduxjs/toolkit";
import { QuestTypeSliceState } from "./questTypeSliceState";
import { QuestTypeResponse } from "../../../models/QuestType/QuestTypeResponse"
import { getQuestTypeList } from "../../utils/thiunks/questTypeThunks";

const initialState: QuestTypeSliceState = {
    loading: true,
    questTypes: [] as QuestTypeResponse[]
};

export const questTypeSlice = createSlice({
    name: "questTypes",
    initialState,
    reducers: {},
    extraReducers: (builder) => {
        builder
            .addCase(getQuestTypeList.pending, (state: QuestTypeSliceState) => {
                state.loading = true;
            })
            .addCase(getQuestTypeList.fulfilled, (state: QuestTypeSliceState, action) => {
                state.loading = false;
                state.questTypes = action.payload;
            })
            .addCase(getQuestTypeList.rejected, (state: QuestTypeSliceState) => {
                state.loading = false;
            });
    }
})
export default questTypeSlice.reducer;