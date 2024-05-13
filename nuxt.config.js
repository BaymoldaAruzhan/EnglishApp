export default {
  // Global page headers: https://go.nuxtjs.dev/config-head
  server: {
    port: 8011, // default: 3000
    host: '0.0.0.0', // default: localhost,
    timing: false
  },
  target: 'server',
  head: {
    htmlAttrs: {
      lang: 'ru'
    },
    titleTemplate: '%s - Онлайн магазин DAMUTECH',
    meta: [
      { charset: 'utf-8' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { hid: 'description', name: 'description', content: process.env.npm_package_description || '' },
      { 'http-equiv': 'x-ua-compatible',  content: 'ie=edge' },
      { name: 'msapplication-TileColor',  content: '#ffffff' },
      { name: 'msapplication-TileImage',  content: '/ms-icon-144x144.png' },
      { name: 'theme-color',  content: '#ffffff' },
      // Facebook open graph
      { property: 'og:type',  content: 'website' },
      { property: 'og:url',  content: 'https://example.com/page.html' },
      { property: 'og:title',  content: 'Content Title' },
      { property: 'og:image',  content: 'https://example.com/image.jpg' },
      { property: 'og:description',  content: 'Description Here' },
      { property: 'og:site_name',  content: 'Site Name' },
      { property: 'og:locale',  content: 'en_US' },
      // Twitter card
      { property: 'twitter:card',  content: 'summary' },
      { property: 'twitter:site',  content: '@site_account' },
      { property: 'twitter:creator',  content: '@individual_account' },
      { property: 'twitter:url',  content: 'https://example.com/page.html' },
      { property: 'twitter:title',  content: 'Content Title' },
      { property: 'twitter:description',  content: 'Content description less than 200 characters' },
      { property: 'twitter:image',  content: 'https://example.com/image.jpg' }
    ],
    link: [
      { rel: 'icon', type: 'image/x-icon', href: '/favicon.png' }
    ],
    script: [
      { hid: 'stripe', src: '//code.jivo.ru/widget/fekdyM3kSR" async', defer: true }
    ]
  },

  loading: {
    color: '#4F5AC2'
  },
  css: [
    // './assets/css/animation.min.css',
    './assets/css/bootstrap.min.css',
    './assets/css/flaticon.css',
    './assets/css/magnific-popup.min.css',
    './assets/css/meanmenu.min.css',
    './assets/css/nice-select.css',
    './assets/css/owl.carousel.min.css',
    './assets/css/owl.theme.default.min.css',
    './assets/css/style.css',
    './assets/css/responsive.css',
  ],

  plugins: [
    '~/plugins/axios',
    '~/plugins/global',
    '~/plugins/notification',
    { src: '~~/plugins/vue-lazy-load.js' },
    { src: '~~/plugins/nuxt-swiper-plugin.js', ssr: false },
    { src: '~~/plugins/toastification', ssr: false },
  ],

  // Auto import components: https://go.nuxtjs.dev/config-components
  components: true,

  // Modules: https://go.nuxtjs.dev/config-modules
  modules: [
    '@nuxtjs/axios',
    // '@nuxtjs/auth',
    // 'nuxt-trailingslash-module',
    'nuxt-webfontloader',
    ['cookie-universal-nuxt', { alias: 'cookiz', parseJSON: false }],
    // https://go.nuxtjs.dev/pwa
    '@nuxtjs/pwa',
  ],
  // PWA module configuration: https://go.nuxtjs.dev/pwa
  pwa: {
    manifest: {
      lang: 'en'
    }
  },
  webfontloader: {
    events: false,
    google: {
      families: ['Montserrat:400,500,600:cyrillic&display=swap']
    },
    timeout: 5000
  },
  axios: {
    proxy: true
  },
  proxy: {
    "/api": {
      target: process.env.API_URL + "api",
      pathRewrite: {
        "^/api": "/"
      }
    }
  },
  robots: {
    UserAgent: '*',
    Allow: '/'
  },
  yandexMetrika: {
    id: '89923483',
  },
  sitemap: {
    path: '/sitemap.xml',
    hostname: 'https://be-tech.kz/',
    gzip: true,
    routes: [
      {
        url: '/',
        changefreq: 'daily',
        priority: 1,
        lastmod: '2022-08-12T13:30:00.000Z'
      },
    ]
  },

  // Build Configuration: https://go.nuxtjs.dev/config-build
  build: {
  }
}
