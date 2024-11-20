import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FundsTrackerComponent } from './funds-tracker.component';

describe('FundsTrackerComponent', () => {
  let component: FundsTrackerComponent;
  let fixture: ComponentFixture<FundsTrackerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FundsTrackerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FundsTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
