export const CommonConstants = {
    returnUrlSnapshot: 'returnUrl'
};

export const UserRoles = {
    administrator: 'admin',
    superadmin: 'super-admin'
};

export const ValidationMessages = {
    EditEvents: {
        title: {
            required: 'Title is required.',
        },
        description: {
            required: 'Description is required.'
        },
        location: {
            required: 'Location is required.'
        },
        startDate: {
            required: 'Start date is required.'
        },
        endDate: {
            required: 'End date is required.'
        }
    },
    Auth: {
        userEmail: {
            required: 'Email is required.',
            email: 'Email is invalid'
        },
        userPassword: {
            required: 'Password is required.'
        }
    }
};
