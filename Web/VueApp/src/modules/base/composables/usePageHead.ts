import { unref } from 'vue'
import { computedEager } from '@vueuse/core'
import { useHead } from '@unhead/vue'
import { useI18n } from 'vue-i18n'
import type { PageSeo } from 'src/core/types'

export const t = (text: string) => useI18n().t(text)

export const usePageHead = (data: PageSeo) => {
  return useHead({
    title: computedEager(() => data.title as string),
    meta: () => {
      if (!data.meta) {
        return []
      }
      return Object.entries(data.meta).map(([name, content]) => ({
        name,
        content: unref(content) ?? '',
      }))
    },
  })
}
