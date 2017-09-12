export const APIConfig = {
    Sites: {
        Portal: {
            Recursos: {
                Eventos: {
                    default: "eventos"
                },
                Carreira: {
                    default: "carreira"
                },
                Objetivos: {
                    default: "objetivos"
                },
                Reunioes: {
                    default: "reunioes"
                }
            },
            Autenticacao: {
                client_id: "Compusafe_Integracao",
                client_secret: "zs7qKNuUBGfWWDrCXmTVZ8s9Da86DA",
                localStorageKey: "CWP.Authorize"
            }
        }
    },
    Header: {
        ContentType: {
            json: 'application/json',
            x_www_form_urlencoded: 'application/x-www-form-urlencoded'
        },
        ResponseType: {
            blob: 'application/octet-stream'
        }
    }
};