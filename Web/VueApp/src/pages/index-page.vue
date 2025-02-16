<template>
  <div class="row">
    <div class="col-12">
      <q-table
        title="Weather Forecasts"
        :rows="forecasts"
        :columns="columns"
        row-key="name"
      ></q-table>
    </div>
  </div>
</template>

<script setup lang="ts">
import { usePageHead, t } from 'modules/base/composables'
import type { WeatherForecast } from 'src/api/web-api-client'
import { onMounted, ref } from 'vue'

const forecasts = ref<WeatherForecast[]>([])

const columns = [
  {
    name: 'date',
    field: 'date',
    required: true,
    label: 'Date',
    align: 'left',
    sortable: true,
  },
  {
    name: 'summary',
    field: 'summary',
    required: true,
    label: 'Summary',
    align: 'left',
    sortable: true,
  },
  {
    name: 'temperatureC',
    field: 'temperatureC',
    required: true,
    label: 'Temperature (C)',
    align: 'left',
    sortable: true,
  },
  {
    name: 'temperatureF',
    field: 'temperatureF',
    required: true,
    label: 'Temperature (F)',
    align: 'left',
    sortable: true,
  },
] as any[]

onMounted(async () => {
  const response = await fetch(
    `${import.meta.env.VITE_API_BASE_URL}/v1/weatherforecasts/public`,
  )
  forecasts.value = (await response.json()) as WeatherForecast[]

  const response2 = await fetch(
    `${import.meta.env.VITE_API_BASE_URL}/v1/weatherforecasts/forecast`,
  )

  console.log(response2)
})

usePageHead({
  title: t('common.app.name'),
})
</script>

<style scoped></style>
