import './App.css'
import QuestTypeTable from './components/QuestType/QuestTable'
import Header from './components/Header/Header'
import MenuNavigation from './components/Menu/MenuNavigation'
import { Layout } from 'antd'
import Sider from 'antd/es/layout/Sider'
import Footer from './components/Footer/Footer'
import { Content } from 'antd/es/layout/layout'
import MainTabContent from './components/MainTabContentComponents/MainTabContent'
import { useState } from 'react'

function App() {

    let [tabsItems, setTabsItems] = useState<Array<any>>([
    ]);

    let [focusTab, setFocusTab] = useState<string>();

    function addTabByKey(key: string) {
        setFocusTab(key);
        if (!tabsItems.some(f => f.key === key)) {
            setTabsItems(prevItems => [...prevItems, getTabByKey(key)])
        }         
    };

    function removeTabByKey(key: string) {
        setTabsItems(tabsItems.filter(f => f.key !== key));            
    };

    function getTabByKey(key: string): any {
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
                    { tab: 'Urz¹dzenia', key: key }
                );
                break;
            }
            case 'EquipmentSetGridKey': {
                return (
                    { tab: 'Grupy urz¹dzeñ', key: key }
                );
                break;
            }
            case 'UserGridKey': {
                return (
                    { tab: 'U¿ytkownicy', key: key }
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

  return (
      <>
          <Layout>
              <Header style={{ display: 'flex', alignItems: 'center' }} />
              <Layout>
                  <Sider>
                      <MenuNavigation style={{ padding: '0 24px', minHeight: 280 }} addTabByKey={addTabByKey} />
                  </Sider>
                  <Content style={{ padding: '0 24px', minHeight: 280 }}>
                      <MainTabContent tabsItems={tabsItems} focusTab={focusTab} removeTabByKey={removeTabByKey} />                   
                  </Content>                  
              </Layout>
              <Footer/>
          </Layout>
          
    </>
  )
}

export default App
