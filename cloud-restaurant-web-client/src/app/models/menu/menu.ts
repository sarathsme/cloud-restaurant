import Dish from "./dish";

export default class Menu {
    public id: string;
    public name: string;
    public description: string;
    public isEnabled: boolean;

    public dishes: Dish[];
}