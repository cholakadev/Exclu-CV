import { TestBed } from '@angular/core/testing';

import { ExclucvServiceService } from './exclucv-service.service';

describe('ExclucvServiceService', () => {
  let service: ExclucvServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ExclucvServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
