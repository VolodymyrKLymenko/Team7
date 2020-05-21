export class User {
    public Id: number;
    public UserRole: string;
    public UserName: string;
}

export class SuperAdmin extends User {

}

export class Administrator extends User {

}