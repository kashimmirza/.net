/** @format */

import React, { useEffect, useState } from "react";
import axios from "axios";
import { baseUrl } from "../constant";

export default function UserListDisplay() {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        const fetchUsers = async() => {
            try {
                const response = await axios.get(`${baseUrl}/api/Admin/userList`);
                console.log(response.data); // Inspect the API response structure

                // Check if the listUsers array exists in the response
                if (Array.isArray(response.data.listUsers)) {
                    setUsers(response.data.listUsers);
                } else {
                    console.error("Expected an array but got", response.data);
                }
            } catch (error) {
                console.error("Failed to fetch users", error);
            }
        };

        fetchUsers();
    }, []);

    return ( <
        div >
        <
        h1 > User List < /h1> <
        ul > {
            Array.isArray(users) ? (
                users.map((user) => ( <
                    li key = { user.id } > { user.firstName } { user.lastName } - { user.email } <
                    /li>
                ))
            ) : ( <
                li > No users found < /li>
            )
        } <
        /ul> < /
        div >
    );
}