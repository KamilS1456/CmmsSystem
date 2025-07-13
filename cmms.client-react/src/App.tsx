import './App.css'
import Header from './components/Header/Header'
import MenuNavigation from './components/Menu/MenuNavigation'
import { Layout } from 'antd'
import Sider from 'antd/es/layout/Sider'
import Footer from './components/Footer/Footer'
import { Content } from 'antd/es/layout/layout'
import MainTabContent from './components/MainTabContentComponents/MainTabContent'
import { useState } from 'react'
import { getTabByKey } from './components/MainTabContentComponents/TabsProvider'
import { ITabsItems } from './components/MainTabContentComponents/ITabsItems'

function App() {

    let [tabsItems, setTabsItems] = useState<Array<ITabsItems>>([]);

    let [focusTab, setFocusTab] = useState<string>();

    function addTabByKey(key: string) {
       
        if (!tabsItems.some(f => f.key === key)) {
            setTabsItems(prevItems => [...prevItems, getTabByKey(key)])
        } 
        setFocusTab(key);
    };

    function removeTabByKey(key: string) {
        setTabsItems(tabsItems.filter(f => f.key !== key));            
    };

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
