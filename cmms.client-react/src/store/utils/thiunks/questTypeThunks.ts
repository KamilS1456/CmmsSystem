import { createAsyncThunk } from "@reduxjs/toolkit";
import type { RootState } from "../..";

import axios, { AxiosResponse } from "axios";
import { API_BASE_URL } from "../../../../config";

import { GetQuestTypeByIdResponse } from "../../../models/QuestType/GetQuestTypeByIdResponse";
import { QuestTypeCreate } from "../../../models/QuestType/QuestTypeCreate";
import { QuestTypeUpdate } from "../../../models/QuestType/QuestTypeUpdate";
import { QuestTypeResponse } from "../../../models/QuestType/QuestTypeResponse";

export const getQuestTypeList = createAsyncThunk<
    QuestTypeResponse[],
    void,
    { state: RootState }
    >
    (
        'questType/getQuestTypeList',
        async ()  => {
            try{
                const response: AxiosResponse<QuestTypeResponse[]> = await axios.get(`${API_BASE_URL}/QuestType`);
                const questTypes = response.data as QuestTypeResponse[];
                return questTypes;
            } catch (error) {
                console.log('Error fetching questtypeList', error)
                throw error;
            }
        }
        
    )
export const getQuestType = createAsyncThunk<
    QuestTypeResponse,
    string
>
    (
        'questType/getQuestType',
        async (id: string) => {
            try {
                const response: AxiosResponse<GetQuestTypeByIdResponse> = await axios.get(`${API_BASE_URL}/QuestType/${id}`);
                const questTypes = response.data.questType as QuestTypeResponse;
                return questTypes;
            } catch (error) {
                console.log('Error fetching questtype', error)
                throw error;
            }
        }
    )

export const createQuestType = createAsyncThunk <
    void,
    QuestTypeCreate>
    (
        'questType/createQuestType',
        async (questTypeCreate: QuestTypeCreate): Promise<void> => {
            try {
                await axios.post(`${API_BASE_URL}/QuestType`, questTypeCreate);
            } catch (error) {
                console.log('Error fetching questtype', error)
                throw error;
            }
        }
)
    
export const updateQuestType = createAsyncThunk<
    void,
    QuestTypeUpdate
>
    (
        'questType/updateQuestType',
        async (questTypeUpdate: QuestTypeUpdate): Promise<void> => {
            try {
                await axios.patch(`${API_BASE_URL}/QuestType`, questTypeUpdate);
            } catch (error) {
                console.log('Error fetching questtype', error)
                throw error;
            }
        }
    );

export const deleteQuestType = createAsyncThunk<
    void,
    string
    >
    (
        'questType/deleteQuestType',    
        async (questTypeId: string): Promise<void> => {
            try {
                await axios.delete(`${API_BASE_URL}/QuestType/${questTypeId}`);
            } catch (error) {
                console.log('Error fetching questtype', error)
                throw error;
            }
        }
    );
