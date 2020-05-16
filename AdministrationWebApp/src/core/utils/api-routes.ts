import { environment } from 'src/environments/environment';

export const ApiRoutes = {
    authenticate: `${environment.serverUrl}/account/login`,
    registerPatient: `${environment.serverUrl}/account/register/admin`,
    resetPassword: `${environment.serverUrl}/account/password`
};
