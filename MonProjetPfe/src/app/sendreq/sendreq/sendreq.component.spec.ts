import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SendreqComponent } from './sendreq.component';

describe('SendreqComponent', () => {
  let component: SendreqComponent;
  let fixture: ComponentFixture<SendreqComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SendreqComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SendreqComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
