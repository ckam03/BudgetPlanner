import { Component } from '@angular/core';
import {
  LucideAngularModule,
  WalletCardsIcon,
  CircleDollarSignIcon,
} from 'lucide-angular';

@Component({
  selector: 'app-funds-tracker',
  imports: [LucideAngularModule],
  templateUrl: './funds-tracker.component.html',
  styleUrl: './funds-tracker.component.css',
})
export class FundsTrackerComponent {
  readonly walletIcon = WalletCardsIcon;
  readonly dollarIcon = CircleDollarSignIcon;
}
