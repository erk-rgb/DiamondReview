import http from "../http";

class DataService {
    getAll() {
        return http.get("/diamond");
    }

    get(id: string) {
        return http.get(`/diamond/${id}`);
    }

    create(data: any) {
        return http.post("/diamond", data);
    }

    update(id: string, data: any) {
        return http.put(`/diamond/${id}`, data);
    }

    delete(id: string) {
        return http.delete(`/diamond/${id}`);
    }

    deleteAll() {
        return http.delete(`/diamond`);
    }
}

export default new DataService();