import { AuthConfig } from 'angular-oauth2-oidc';

export const authConfig: AuthConfig = {

    issuer: 'https://localhost:5001',
    clientId: 'spa',
    postLogoutRedirectUri: 'http://localhost:4200/',
    redirectUri: window.location.origin + "/login-callback",
    scope:"openid profile api1",
    oidc: true,
}