import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilesviewComponent } from './filesview.component';

describe('FilesviewComponent', () => {
  let component: FilesviewComponent;
  let fixture: ComponentFixture<FilesviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FilesviewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FilesviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
