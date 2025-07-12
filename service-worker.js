const CACHE_NAME = 'invoice-app-v1';
const urlsToCache = [
  '/',
  '/login.html',
  '/main.html',
  '/manage.html',
  '/reports.html',
  '/manifest.json',
  '/brands.png',
  '/yaasc_logo.png',
  '/icon-192.png',
  '/icon-512.png'
];
self.addEventListener('install', event => {
  event.waitUntil(caches.open(CACHE_NAME).then(cache => cache.addAll(urlsToCache)));
});
self.addEventListener('fetch', event => {
  event.respondWith(caches.match(event.request).then(response => response || fetch(event.request)));
});