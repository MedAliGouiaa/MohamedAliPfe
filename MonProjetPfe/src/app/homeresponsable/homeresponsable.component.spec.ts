import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeresponsableComponent } from './homeresponsable.component';

describe('HomeresponsableComponent', () => {
  let component: HomeresponsableComponent;
  let fixture: ComponentFixture<HomeresponsableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HomeresponsableComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeresponsableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
