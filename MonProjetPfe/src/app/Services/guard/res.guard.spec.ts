import { TestBed } from '@angular/core/testing';

import { ResGuard } from './res.guard';

describe('ResGuard', () => {
  let guard: ResGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(ResGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
