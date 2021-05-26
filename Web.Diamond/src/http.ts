import axios from "axios";

export default axios.create({
    baseURL: "http://localhost:53205/api",
    headers: {
        "Content-type": "application/json"
    }
});
