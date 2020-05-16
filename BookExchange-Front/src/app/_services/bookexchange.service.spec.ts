/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { BookexchangeService } from './bookexchange.service';

describe('Service: Bookexchange', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BookexchangeService]
    });
  });

  it('should ...', inject([BookexchangeService], (service: BookexchangeService) => {
    expect(service).toBeTruthy();
  }));
});
