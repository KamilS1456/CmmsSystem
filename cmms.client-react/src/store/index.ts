import { configureStore } from "@reduxjs/toolkit"
import QuestTypesReducer from "./reducers/questTypeReducer/QuestTypesReducer"
import QuestsReducer from "./reducers/questReducer/QuestsReducer"

export const store = configureStore({
    reducer: {
        questTypes: QuestTypesReducer,
        quests: QuestsReducer
    }
})

export type RootState = ReturnType<typeof store.getState>;

export type AppDispatch = typeof store.dispatch;