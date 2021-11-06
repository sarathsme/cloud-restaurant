import { Component, OnInit } from '@angular/core';
import Menu from 'src/app/models/menu/menu';
import { MenuService } from 'src/app/services/menu.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  public AllMenus: Menu[] = [];
  public SelectedMenu: Menu;

  constructor(private menuService: MenuService) { }

  // TODO: Group by category?
  // TODO: Add a model
  ngOnInit() {
    this.menuService.GetAllMenus().subscribe((allMenus) => {
      this.AllMenus = allMenus;

      if(this.AllMenus && this.AllMenus.length) {
        this.SelectedMenu = this.AllMenus.find(menu => menu.isEnabled);
        this.SelectedMenu.dishes = this.SelectedMenu.dishes.filter(dish => dish.isAvailable);
      }
    });
  }
}
