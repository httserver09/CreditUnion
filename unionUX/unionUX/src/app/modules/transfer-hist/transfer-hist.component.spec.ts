import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferHistComponent } from './transfer-hist.component';

describe('TransferHistComponent', () => {
  let component: TransferHistComponent;
  let fixture: ComponentFixture<TransferHistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TransferHistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TransferHistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
