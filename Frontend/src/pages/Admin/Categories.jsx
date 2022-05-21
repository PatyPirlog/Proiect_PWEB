import React, { useCallback, useState, useEffect } from "react";
import { useAuth0 } from "@auth0/auth0-react";
import Layout from "../../utils/Layout";
import axiosInstance from "../../configs/Axios";
import { routes } from "../../configs/Api";
import { Link, useNavigate  } from "react-router-dom";
import jwt from 'jwt-decode';

const Categories = () => {
  const { getAccessTokenSilently } = useAuth0();
  const [categories, setCategories] = useState([]);

  const [permissions, setPermissions] = useState("");
  const navigate = useNavigate();
  
  const getPermissions = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    const data = jwt(accessToken);
    setPermissions(data.permissions);
    console.log(data);

  }, [getAccessTokenSilently]);

  useEffect(() => {
    getPermissions()
  }, []);

  const getAllCategories = useCallback(async () => {
    const accessToken = await getAccessTokenSilently();
    //console.log(user);
    axiosInstance
      .get(routes.category.getAll, {
        headers: {
          Authorization: `Bearer ${accessToken}`,
        },
      })
      .then(({ data }) => {
        setCategories(data)
      })
      .catch((error) => {
        if(error.response.status === 403)
          navigate('/unauthorized');
      });
  }, [getAccessTokenSilently]);
 
  useEffect(() => {
    getAllCategories();
  }, [getAllCategories]);

  // de adaugat si permisions
  return (
    <>       
        {
        permissions[0] === "admin" &&
        categories.map((category) => {
          return(
            <>
                <p>{category.id}</p>
                <p>{category.name}</p>
            </>
          )
      })
      }
    </>
  );
};

export default Categories;
