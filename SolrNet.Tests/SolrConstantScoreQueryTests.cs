﻿#region license
// Copyright (c) 2007-2010 Mauricio Scheffer
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//      http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using Xunit;
using SolrNet.Impl.FieldSerializers;
using SolrNet.Impl.QuerySerializers;

namespace SolrNet.Tests {
    
    public class SolrConstantScoreQueryTests {
        [Fact]
        public void ConstantScore() {
            var q = new SolrConstantScoreQuery(new SolrQuery("solr"), 34.2);
            var serializer = new DefaultQuerySerializer(new DefaultFieldSerializer());
            var query = serializer.Serialize(q);
            Assert.Equal("(solr)^=34.2", query);
        }

        [Fact]
        public void ConstantScore_with_high_value() {
            var q = new SolrConstantScoreQuery(new SolrQuery("solr"), 34.2E10);
            var serializer = new DefaultQuerySerializer(new DefaultFieldSerializer());
            var query = serializer.Serialize(q);
            Assert.Equal("(solr)^=342000000000", query);
        }

        [Fact]
        public void SolrQuery_ConstantScore() {
            var q = new SolrQuery("solr").Boost(12.2);
            var serializer = new DefaultQuerySerializer(new DefaultFieldSerializer());
            var query = serializer.Serialize(q);
            Assert.Equal("(solr)^=12.2", query);
        }
    }
}