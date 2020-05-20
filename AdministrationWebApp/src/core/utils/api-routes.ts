import { environment } from 'src/environments/environment';

export const ApiRoutes = {
    authenticate: `${environment.serverUrl}/accounts/login`,
    registerPatient: `${environment.serverUrl}/accounts/register/admin`,
    resetPassword: `${environment.serverUrl}/accounts/password`,

    events: `${environment.serverUrl}/events`
};
