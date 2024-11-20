import { Component } from '@angular/core';
import {
  LucideAngularModule,
  HouseIcon,
  BanknoteIcon,
  ChartLineIcon,
  ChevronUpIcon,
} from 'lucide-angular';

@Component({
    selector: 'app-sidebar',
    imports: [LucideAngularModule],
    templateUrl: './sidebar.component.html',
    styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  readonly HouseIcon = HouseIcon;
  readonly BanknoteIcon = BanknoteIcon;
  readonly ChartLineIcon = ChartLineIcon;
  readonly ChevronUpIcon = ChevronUpIcon;
}
