using NUnit.Framework;
using Neo4jClient.Gremlin;

namespace Neo4jClient.Test.Gremlin
{
    [TestFixture]
    public class AggregateStepTests
    {
        [Test]
        public void AggregateVShouldAppendStepAndDeclareVariable()
        {
            var query = new NodeReference(123).AggregateV<object>("foo");
            Assert.AreEqual("foo = [];g.v(p0).aggregate(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void AggregateVShouldReturnTypedNodeEnumerable()
        {
            var query = new NodeReference(123).AggregateV<object>("foo");
            Assert.IsInstanceOf<GremlinNodeEnumerable<object>>(query);
        }

        [Test]
        public void AggregateEShouldAppendStepAndDeclareVariable()
        {
            var query = new NodeReference(123).AggregateE("foo");
            Assert.AreEqual("foo = [];g.v(p0).aggregate(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void AggregateEShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).AggregateE("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable>(query);
        }

        [Test]
        public void AggregateEWithTDataShouldAppendStepAndDeclareVariable()
        {
            var query = new NodeReference(123).AggregateE<object>("foo");
            Assert.AreEqual("foo = [];g.v(p0).aggregate(foo)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void AggregateEWithTDataShouldAppendStepAndDeclareVariables()
        {
            var query = new NodeReference(123).AggregateE<object>("foo").AggregateE<object>("bar");
            Assert.AreEqual("bar = [];foo = [];g.v(p0).aggregate(foo).aggregate(bar)", query.QueryText);
            Assert.AreEqual(123, query.QueryParameters["p0"]);
        }

        [Test]
        public void AggregateEWithTDataShouldReturnRelationshipEnumerable()
        {
            var query = new NodeReference(123).AggregateE<object>("foo");
            Assert.IsInstanceOf<GremlinRelationshipEnumerable<object>>(query);
        }
    }
}