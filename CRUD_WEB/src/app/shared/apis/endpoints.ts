export const Endpoint = {
    Persona: {
        LIST_PERSONA: 'Persona',
        LIST_SELECT_PERSONA: 'Persona/Select',
        PERSONA_BY_ID: 'Persona/GetByID/',
        PERSONA_REGISTER: 'Persona/Register',
        PERSONA_EDIT: 'Persona/Edit/',
        PERSONA_REMOVE: 'Persona/Remove/'
    },
    
    Rol: {
        LIST_ROL: 'Rol',
        LIST_SELECT_ROL: 'Rol/Select',
        ROL_REGISTER: 'Rol/Register',
        ROL_EDIT: 'Rol/Edit/',
        ROL_REMOVE: 'Rol/Remove/'
    },

    Usuario: {
        LIST_USUARIO: 'Usuario',
        USUARIO_BY_ID: 'Usuario/GetByID/',
        USUARIO_REGISTER: 'Usuario/Register',
        USUARIO_EDIT: 'Usuario/Edit/',
        USUARIO_REMOVE: 'Usuario/Remove/'
    },

    Dashboard: {
        LIST_ADMIN_DASHBOARD: 'Dashboard/Administrador',
        LIST_USER_DASHBOARD: 'Dashboard/User'
    },
    
    Sesion: {
        LIST_SESSIONS: 'Sesion',
        LIST_SESSIONS_BY_ID: 'Sesion/GetByID/',
        END_SESSION: 'Sesion/EndSession/'
    },

    Permiso: {
        LIST_PERMISSES_PER_ROLE: 'Permiso/'
    },

    Login: {
        REGISTER_USER_PERSON: 'Login/Register',
        START_SESSION: 'Login/SessionStart'
    }
}