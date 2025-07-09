import { createAsyncThunk } from "@reduxjs/toolkit";
import type { RootState } from "../../index";

import axios, { AxiosResponse } from "axios";
import { API_BASE_URL } from "../../../../config";
import { QuestCreate } from "../../../models/Quest/QuestCreate";
import { QuestResponse } from "../../../models/Quest/QuestResponse";
import { QuestUpdate } from "../../../models/Quest/QuestUpdate";
import { GetQuestByIdResponse } from "../../../models/Quest/GetQuestByIdResponse";

export const getQuestList = createAsyncThunk<
    QuestResponse[],
    void,
    { state: RootState }
    >
    (
        'quest/getQuestList',
        async ()  => {
            try{
                const response: AxiosResponse<QuestResponse[]> = await axios.get(`${API_BASE_URL}/Quest`);
                const quests = response.data as QuestResponse[];
                return quests;
            } catch (error) {
                console.log('Error fetching questList', error)
                throw error;
            }
        }
        
    )
export const getQuest = createAsyncThunk<
    QuestResponse,
    string
>
    (
        'quest/getQuest',
        async (id: string) => {
            try {
                const response: AxiosResponse<GetQuestByIdResponse> = await axios.get(`${API_BASE_URL}/Quest/${id}`);
                const quest = response.data.quest as QuestResponse;
                return quest;
            } catch (error) {
                console.log('Error fetching quest', error)
                throw error;
            }
        }
    )

export const createQuest = createAsyncThunk <
    void,
    QuestCreate>
    (
        'quest/createQuest',
        async (questCreate: QuestCreate): Promise<void> => {
            try {
                await axios.post(`${API_BASE_URL}/Quest`, questCreate);
            } catch (error) {
                console.log('Error fetching quest', error)
                throw error;
            }
        }
)
    
export const updateQuest = createAsyncThunk<
    void,
    QuestUpdate
>
    (
        'quest/updateQuest',
        async (questUpdate: QuestUpdate): Promise<void> => {
            try {
                await axios.patch(`${API_BASE_URL}/Quest`, questUpdate);
            } catch (error) {
                console.log('Error fetching quest', error)
                throw error;
            }
        }
    );

export const deleteQuest = createAsyncThunk<
    void,
    string
    >
    (
        'quest/deleteQuest',    
        async (questId: string): Promise<void> => {
            try {
                await axios.delete(`${API_BASE_URL}/Quest/${questId}`);
            } catch (error) {
                console.log('Error fetching quest', error)
                throw error;
            }
        }
    );