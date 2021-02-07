export default class LazyLofiApi {
    static getVideos() {
        const requestOptions = this.createGetObject();
        return LazyLofiFetch('/api/backend', requestOptions);
    }

    static createGetObject<T>(): any {
        return {
            method: 'GET',
        };
    }

    static createPostObject<T>(data: T): any {
        return {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data),
        };
    }

    static createPutObject<T>(data: T): any {
        return {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(data)
        }
    }
}

const LazyLofiFetch = (url: string, requestOptions: any) => {
    return fetch(url, requestOptions)
        .then(res => {
            if (res.status == 200) {
                return res.json();
            }
            else if (res.status == 201) {
                return res;
            }
            else {
                return Promise.reject({
                    status: res.status,
                    statusText: res.statusText,
                    url,
                    requestOptions
                });
            }
        });
}