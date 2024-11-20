import {
  HttpHandlerFn,
  HttpInterceptorFn,
  HttpRequest,
} from '@angular/common/http';

export const httpInterceptor: HttpInterceptorFn = (
  req: HttpRequest<unknown>,
  next: HttpHandlerFn
) => {
  console.log(req.url);

  const newReq = req.clone({
    headers: req.headers
      .set('Content-Type', 'application/json')
      .set('mode', 'cors'),
  });
  return next(newReq);
};
