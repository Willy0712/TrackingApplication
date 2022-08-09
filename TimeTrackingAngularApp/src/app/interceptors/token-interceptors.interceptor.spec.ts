import { TestBed } from '@angular/core/testing';

import { TokenInterceptorsInterceptor } from './token-interceptors.interceptor';

describe('TokenInterceptorsInterceptor', () => {
  beforeEach(() => TestBed.configureTestingModule({
    providers: [
      TokenInterceptorsInterceptor
      ]
  }));

  it('should be created', () => {
    const interceptor: TokenInterceptorsInterceptor = TestBed.inject(TokenInterceptorsInterceptor);
    expect(interceptor).toBeTruthy();
  });
});
