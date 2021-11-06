import Price from "./price";

export default class Dish {
    public id: string;
    public name: string;
    public description: string;
    public category: string;
    public isAvailable: boolean;
    public price: Price;
    public userRating: number;
    public tags: string[];
    public imageUrl: string;
    public availableTimeOfDay: string[];
    public waitingTime: number;
}