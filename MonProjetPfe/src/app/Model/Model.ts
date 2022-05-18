import { Role } from "./role";
export class Model {
  id: number = 0;
  nom: string;
  prenom: string;
  email: string;
  motpasse: string;
  role: Role;

}
