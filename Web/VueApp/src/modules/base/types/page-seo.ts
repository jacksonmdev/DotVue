import type { MaybeRef } from 'vue'

export type PageSeo = {
  title?: MaybeRef<string | string[] | undefined>
  meta?: Record<string, MaybeRef<string | undefined>>
}
