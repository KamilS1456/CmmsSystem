import { Button } from "antd"
import React, { useState, useEffect } from 'react';

const restaurantEdit = () => {
    const getQuesturl = 'https://localhost:5001/api/quest/4'
    const [loadings, setLoadings] = useState([]);
    const [photos, setPhotos] = useState([]);

    const fetchQuestData = async (index) => {
        enterLoading(index)
        console.log(1)
        const response = await fetch(getQuesturl)
         .then((response) => {
            console.log(response)
            console.log(2)
            return response.json()            
        })
         .then((data) => {
            console.log(3)
            console.log(data);
            setPhotos(data);
            return data;
         })
         .catch((err) => {
            console.log(4)
            console.log(err.message);
         });
         console.log(5)
         console.log(response)
         console.log(6)
         console.log(photos)

         leaveLoading(index)
    }
    const enterLoading = (index) => {
        setLoadings((prevLoadings) => {
          const newLoadings = [...prevLoadings];
          newLoadings[index] = true;
          return newLoadings;
        });
    }

    const leaveLoading = (index) => {
        setLoadings((prevLoadings) => {
          const newLoadings = [...prevLoadings];
          newLoadings[index] = false;
          return newLoadings;
        });
    }

    return (
        <div>
            <Button type="primary" 
            loading = {loadings[1]}
            onClick= {() => fetchQuestData(1)}
            >
                Loading
            </Button>
        </div>
    )   
}
export default restaurantEdit