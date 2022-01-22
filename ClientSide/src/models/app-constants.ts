export interface API {
    residents: string;
    residentsByName: string;
}

export class AppConstants {
    static readonly api: API = {
        residents: '/api/resident',
        residentsByName: '/api/Resident/getAllResidentsByCity',
    }
}