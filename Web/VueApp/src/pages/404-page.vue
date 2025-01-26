<template>
  <q-layout>
    <q-page-container>
      <q-page class="page-wrapper flex flex-center q-pa-xl">
        <div class="text-center">
          <div>
            <h5 class="text-caption text-uppercase text-bold">
              {{ t('errors.404.tagline') }}
            </h5>
            <h1 class="text-bold q-my-xl">{{ t('errors.404.title') }}</h1>
            <p class="text-subtitle2 text-italic">
              {{ t('errors.404.caption1') }}
            </p>
            <p class="text-subtitle2 text-uppercase text-bold">
              {{ t('errors.404.caption2') }}
            </p>
          </div>
          <q-btn
            class="q-mt-md"
            color="orange"
            outline
            :label="t('errors.404.button_text')"
            :to="'/'"
          />
        </div>
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import { usePageHead, t } from 'modules/base/composables'

usePageHead({
  title: t('errors.404.tagline'),
})
</script>

<style scoped>
h1 {
  font-size: 10rem;
}
</style>
