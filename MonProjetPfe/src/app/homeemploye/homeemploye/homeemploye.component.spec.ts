import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeemployeComponent } from './homeemploye.component';

describe('HomeemployeComponent', () => {
  let component: HomeemployeComponent;
  let fixture: ComponentFixture<HomeemployeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeemployeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeemployeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
