import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferSummComponent } from './transfer-summ.component';

describe('TransferSummComponent', () => {
  let component: TransferSummComponent;
  let fixture: ComponentFixture<TransferSummComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransferSummComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransferSummComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
