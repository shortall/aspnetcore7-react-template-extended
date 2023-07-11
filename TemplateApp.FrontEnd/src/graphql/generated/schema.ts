import { gql } from '@apollo/client';
import * as Apollo from '@apollo/client';
export type Maybe<T> = T | null;
export type InputMaybe<T> = Maybe<T>;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
export type MakeOptional<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]?: Maybe<T[SubKey]> };
export type MakeMaybe<T, K extends keyof T> = Omit<T, K> & { [SubKey in K]: Maybe<T[SubKey]> };
export type MakeEmpty<T extends { [key: string]: unknown }, K extends keyof T> = { [_ in K]?: never };
export type Incremental<T> = T | { [P in keyof T]?: P extends ' $fragmentName' | '__typename' ? T[P] : never };
const defaultOptions = {} as const;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: { input: string; output: string; }
  String: { input: string; output: string; }
  Boolean: { input: boolean; output: boolean; }
  Int: { input: number; output: number; }
  Float: { input: number; output: number; }
  DateTime: { input: any; output: any; }
};

export type Query = {
  __typename?: 'Query';
  weatherForecasts: Array<WeatherForecast>;
};

export type WeatherForecast = {
  __typename?: 'WeatherForecast';
  date: Scalars['DateTime']['output'];
  id: Scalars['Int']['output'];
  summary?: Maybe<Scalars['String']['output']>;
  temperatureC: Scalars['Int']['output'];
  temperatureF: Scalars['Int']['output'];
};

export type GetWeatherForecastsQueryVariables = Exact<{ [key: string]: never; }>;


export type GetWeatherForecastsQuery = { __typename?: 'Query', weatherForecasts: Array<{ __typename?: 'WeatherForecast', date: any, id: number, summary?: string | null, temperatureC: number, temperatureF: number }> };


export const GetWeatherForecastsDocument = gql`
    query GetWeatherForecasts {
  weatherForecasts {
    date
    id
    summary
    temperatureC
    temperatureF
  }
}
    `;

/**
 * __useGetWeatherForecastsQuery__
 *
 * To run a query within a React component, call `useGetWeatherForecastsQuery` and pass it any options that fit your needs.
 * When your component renders, `useGetWeatherForecastsQuery` returns an object from Apollo Client that contains loading, error, and data properties
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useGetWeatherForecastsQuery({
 *   variables: {
 *   },
 * });
 */
export function useGetWeatherForecastsQuery(baseOptions?: Apollo.QueryHookOptions<GetWeatherForecastsQuery, GetWeatherForecastsQueryVariables>) {
        const options = {...defaultOptions, ...baseOptions}
        return Apollo.useQuery<GetWeatherForecastsQuery, GetWeatherForecastsQueryVariables>(GetWeatherForecastsDocument, options);
      }
export function useGetWeatherForecastsLazyQuery(baseOptions?: Apollo.LazyQueryHookOptions<GetWeatherForecastsQuery, GetWeatherForecastsQueryVariables>) {
          const options = {...defaultOptions, ...baseOptions}
          return Apollo.useLazyQuery<GetWeatherForecastsQuery, GetWeatherForecastsQueryVariables>(GetWeatherForecastsDocument, options);
        }
export type GetWeatherForecastsQueryHookResult = ReturnType<typeof useGetWeatherForecastsQuery>;
export type GetWeatherForecastsLazyQueryHookResult = ReturnType<typeof useGetWeatherForecastsLazyQuery>;
export type GetWeatherForecastsQueryResult = Apollo.QueryResult<GetWeatherForecastsQuery, GetWeatherForecastsQueryVariables>;