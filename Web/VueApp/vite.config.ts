import { fileURLToPath, URL } from 'node:url'
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import { quasar, transformAssetUrls } from '@quasar/vite-plugin'

// https://vitejs.dev/config/
export default defineConfig({
  server: {
    port: 4000,
  },
  plugins: [
    vue({
      template: { transformAssetUrls },
    }),
    quasar({
      sassVariables: 'src/assets/quasar-variables.scss',
    }),
  ],
  resolve: {
    alias: {
      src: fileURLToPath(new URL('./src', import.meta.url)),
      modules: fileURLToPath(new URL('./src/modules', import.meta.url)),
    },
  },
})
